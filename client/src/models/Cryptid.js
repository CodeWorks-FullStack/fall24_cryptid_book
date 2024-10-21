import { Profile } from "./Profile.js"

export class Cryptid {

  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.name = data.name
    this.threatLevel = data.threatLevel
    this.imgUrl = data.imgUrl
    this.origin = data.origin
    this.size = data.size
    this.cryptidCode = data.cryptidCode
    this.discovererId = data.discovererId
    this.discoverer = new Profile(data.discoverer)
  }
}