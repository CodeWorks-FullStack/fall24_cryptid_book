import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { TrackedCryptidProfile } from "@/models/TrackedCryptidProfile.js"
import { AppState } from "@/AppState.js"
import { TrackedCryptidCryptid } from "@/models/TrackedCryptidCryptid.js"

class TrackedCryptidsService {
  async getCryptidsIAmTracking() {
    const response = await api.get('account/trackedCryptids')
    logger.log('GOT TRACKED CRYPTIDS', response.data)
    AppState.myTrackedCryptidCryptids = response.data.map(cryptidPOJO => new TrackedCryptidCryptid(cryptidPOJO))

  }
  async deleteTrackedCryptid(trackedCryptidId) {
    const response = await api.delete(`api/trackedCryptids/${trackedCryptidId}`)
    logger.log('DELETED TRACKED CRYPTID', response.data)

    const foundProfileIndex = AppState.trackedCryptidProfiles.findIndex(tracker => tracker.trackedCryptidId == trackedCryptidId)
    AppState.trackedCryptidProfiles.splice(foundProfileIndex, 1)

    const foundCryptidIndex = AppState.myTrackedCryptidCryptids.findIndex(tracker => tracker.trackedCryptidId == trackedCryptidId)
    AppState.myTrackedCryptidCryptids.splice(foundCryptidIndex, 1)
  }
  async getTrackersByCryptidId(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}/trackedCryptids`)
    logger.log('GOT TRACKERS', response.data)
    const trackers = response.data.map(trackerPOJO => new TrackedCryptidProfile(trackerPOJO))
    AppState.trackedCryptidProfiles = trackers
  }
  async createTrackedCryptid(trackedCryptidData) {
    const response = await api.post('api/trackedCryptids', trackedCryptidData)
    logger.log('TRACKING CRYPTID', response.data)
    const newTracker = new TrackedCryptidProfile(response.data)
    AppState.trackedCryptidProfiles.push(newTracker)
  }
}

export const trackedCryptidsService = new TrackedCryptidsService()