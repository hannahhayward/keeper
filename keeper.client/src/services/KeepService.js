import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepService {
  async getKeeps(url = 'api/keeps') {
    const res = await api.get(url)
    logger.log(res.data, 'keeps data')
    AppState.keeps = res.data
  }

  async getById(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data
  }
}
export const keepService = new KeepService()
