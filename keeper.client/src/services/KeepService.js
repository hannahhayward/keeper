import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepService {
  async getKeeps(url = 'api/keeps') {
    const res = await api.get(url)
    logger.log(res.data, 'keeps')
    AppState.keeps = res.data
  }
}
export const keepService = new KeepService()
