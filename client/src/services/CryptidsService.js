import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Cryptid } from "@/models/Cryptid.js"
import { AppState } from "@/AppState.js"

class CryptidsService {
  async createCryptid(cryptidData) {
    const response = await api.post('api/cryptids', cryptidData)
    logger.log('CREATED CRYPTID', response.data)
    const newCryptid = new Cryptid(response.data)
    AppState.cryptids.push(newCryptid)
  }
  async getCryptidById(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}`);
    logger.log('GOT CRYPTID BY ID 👽', response.data)
    const cryptid = new Cryptid(response.data)
    AppState.activeCryptid = cryptid
  }
  async getAllCryptids() {
    const response = await api.get('api/cryptids');
    logger.log('GOT CRYPTIDS 👹👽🧌', response.data);
    const cryptids = response.data.map(cryptidPOJO => new Cryptid(cryptidPOJO));
    AppState.cryptids = cryptids;
  }

}

export const cryptidsService = new CryptidsService()