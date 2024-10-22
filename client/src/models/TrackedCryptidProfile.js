import { Profile } from "./Profile.js";

export class TrackedCryptidProfile extends Profile {
  constructor(data) {
    super(data)
    this.trackedCryptidId = data.trackedCryptidId
  }
}