import { Cryptid } from "./Cryptid.js";

export class TrackedCryptidCryptid extends Cryptid {
  constructor(data) {
    super(data)
    this.trackedCryptidId = data.trackedCryptidId
  }
}