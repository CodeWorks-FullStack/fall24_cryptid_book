import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { TrackedCryptidProfile } from "@/models/TrackedCryptidProfile.js"
import { AppState } from "@/AppState.js"

class TrackedCryptidsService {
  async getTrackersByCryptidId(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}/trackedCryptids`)
    logger.log('GOT TRACKERS', response.data)
    const trackers = response.data.map(trackerPOJO => new TrackedCryptidProfile(trackerPOJO))
    AppState.trackedCryptidProfiles = trackers
  }
  async createTrackedCryptid(trackedCryptidData) {
    const response = await api.post('api/trackedCryptids', trackedCryptidData)
    logger.log('TRACKING CRYPTID', response.data)
  }
}

export const trackedCryptidsService = new TrackedCryptidsService()