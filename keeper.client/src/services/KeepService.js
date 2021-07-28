import { AppState } from '../AppState'
import { api } from './AxiosService'

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

  async getKeepsByVaultId(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.activeProfileKeeps = []
    AppState.activeVaultKeeps = res.data
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps/', newKeep)
    AppState.keeps = res.data
  }
}
export const keepService = new KeepService()
