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
    logger.log(res.data, 'user vaults in the serv')
    AppState.userVaults = res.data
  }

  async getById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }

  async createVault(newVault) {
    logger.log(newVault, 'new vault in the service')
    const res = await api.post('api/vaults/', newVault)
    AppState.activeProfileVaults = res.data
  }

  async createVaultKeep(newVk) {
    const res = await api.post('api/vaultkeeps/', newVk)
    logger.log(res.data, 'that new vault keep')
  }
}
export const vaultService = new VaultService()
