import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultService {
  async getVaultsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.activeProfileVaults = res.data
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
}
export const vaultService = new VaultService()
