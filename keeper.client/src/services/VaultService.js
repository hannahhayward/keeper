import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { keepService } from './KeepService'

class VaultService {
  async getVaultsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.activeProfileVaults = res.data
  }

  async getUserVaults(id) {
    if (id == null) {
      return 'you are not logged in'
    }
    const res = await api.get(`api/profiles/${id}/vaults`)
    logger.log(res.data)
    AppState.activeProfileVaults = res.data
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

  async deleteVaultKeep(keep) {
    await api.delete('api/vaultkeeps/' + keep.vaultKeepId)
    AppState.activeVaultKeeps = AppState.activeVaultKeeps.filter(k => k.id !== keep.vaultKeepId)
  }
}
export const vaultService = new VaultService()
