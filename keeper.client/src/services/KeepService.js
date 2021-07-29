import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { vaultService } from './VaultService'

class KeepService {
  async getKeeps(url = 'api/keeps') {
    const res = await api.get(url)
    AppState.keeps = res.data
  }

  async getById(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.activeProfileKeeps = res.data
  }

  async getKeepsByVaultId(id, userId) {
    const res = await api.get(`api/vaults/${id}/keeps`, userId)
    AppState.activeProfileKeeps = []
    AppState.activeVaultKeeps = res.data
    logger.log(res.data, 'keeps')
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps/', newKeep)
    AppState.activeProfileKeeps = [res.data, ...AppState.activeProfileKeeps]
  }

  async updateKeep(newKeep) {
    const id = newKeep.id
    const res = await api.put(`api/keeps/${id}`, newKeep)
    logger.log(newKeep, 'view count go up?')
    AppState.activeKeep = res.data
  }

  async deleteKeep(id) {
    const res = await api.delete('api/keeps/' + id)
    logger.log(res.data)
  }
}
export const keepService = new KeepService()
