import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultService {
  async getVaultsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.activeProfileVaults = []
    AppState.activeProfileVaults = res.data
  }

  async getUserVaults(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.userVaults = res.data
  }

  async getById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }

  async createVault(newVault) {
    const res = await api.post('api/vaults/', newVault)
    AppState.activeProfileVaults = [res.data, ...AppState.activeProfileVaults]
  }

  async createVaultKeep(newVk) {
    const res = await api.post('api/vaultkeeps/', newVk)
    AppState.userVaults = res.data
  }

  async deleteVault(id) {
    await api.delete('api/vaults/' + id)
    AppState.activeProfileVaults = AppState.activeProfileVaults.filter(v => v.id !== id)
  }

  async deleteVaultKeep(keepId) {
    AppState.activeVaultKeeps = AppState.activeVaultKeeps.filter(k => k.id !== keepId)
  }
}
export const vaultService = new VaultService()
