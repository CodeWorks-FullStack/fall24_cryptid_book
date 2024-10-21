import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class CryptidsService {
  async getAllCryptids() {
    const response = await api.get('api/cryptids')
    logger.log('GOT CRYPTIDS 👹👽🧌', response.data)
  }

}

export const cryptidsService = new CryptidsService()