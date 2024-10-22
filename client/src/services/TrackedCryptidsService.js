import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class TrackedCryptidsService {
  async createTrackedCryptid(trackedCryptidData) {
    const response = await api.post('api/trackedCryptids', trackedCryptidData)
    logger.log('TRACKING CRYPTID', response.data)
  }
}

export const trackedCryptidsService = new TrackedCryptidsService()