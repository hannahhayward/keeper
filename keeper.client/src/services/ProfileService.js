import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile(id) {
    if (id === undefined) {
      const res = await api.get('api/profiles/' + 4)
      AppState.activeProfile = res.data
    }
    const res = await api.get('api/profiles/' + id)
    AppState.activeProfile = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log(res.data, 'keeps by profile id')
  }
}
export const profileService = new ProfileService()
