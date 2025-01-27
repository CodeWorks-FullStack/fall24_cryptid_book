<script setup>
import { AppState } from '@/AppState.js';
import ProfilePicture from '@/components/ProfilePicture.vue';
import { cryptidsService } from '@/services/CryptidsService.js';
import { trackedCryptidsService } from '@/services/TrackedCryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted, onUnmounted, watch } from 'vue';
import { useRoute } from 'vue-router';

const cryptid = computed(() => AppState.activeCryptid)
const account = computed(() => AppState.account)
const trackers = computed(() => AppState.trackedCryptidProfiles)
const foundTracker = computed(() => trackers.value.find(tracker => tracker.id == account.value?.id))
const route = useRoute()

onMounted(() => {
  getCryptidById()
  getTrackersByCryptidId()
})

watch(cryptid, () => {
  if (!cryptid.value) return
  document.querySelector('main').style.backgroundImage = `url(${cryptid.value.imgUrl})`
})

onUnmounted(() => {
  document.querySelector('main').style.backgroundImage = 'unset'
})

async function getCryptidById() {
  try {
    await cryptidsService.getCryptidById(route.params.cryptidId)
  } catch (error) {
    Pop.meow(error)
    logger.error(error)
  }
}

async function getTrackersByCryptidId() {
  try {
    await trackedCryptidsService.getTrackersByCryptidId(route.params.cryptidId)
  } catch (error) {
    Pop.meow(error)
    logger.error(error)
  }
}

async function createTrackedCryptid() {
  try {
    const trackedCryptidData = { cryptidId: route.params.cryptidId }
    await trackedCryptidsService.createTrackedCryptid(trackedCryptidData)
  } catch (error) {
    Pop.meow(error)
    logger.error(error)
  }
}

async function deleteTrackedCryptid() {
  try {
    const yes = await Pop.confirm(`Are you sure that you want to end your relationship with ${cryptid.value.name}?`)
    if (!yes) return
    await trackedCryptidsService.deleteTrackedCryptid(foundTracker.value.trackedCryptidId)
  }
  catch (error) {
    Pop.meow(error)
    logger.error(error)
  }
}

</script>


<template>
  <div v-if="cryptid" class="container">
    <section class="row my-3">
      <div class="col-12">
        <div class="text-danger">
          <h1 class="kablammo-font">{{ cryptid.name }}</h1>
          <h2>Case #{{ cryptid.cryptidCode.slice(cryptid.cryptidCode.lastIndexOf('-') + 1) }}</h2>
          <h2>Discovered by {{ cryptid.discoverer.name }}</h2>
          <h2 class="text-capitalize">{{ cryptid.origin }} {{ cryptid.size }}</h2>
          <div>
            <h2 :title="'Threat Level: ' + cryptid.threatLevel + '/10'">
              Threat Level
              <i v-for="threatNumber in 10" :key="threatNumber" class="mdi mdi-skull fs-1"
                :class="{ 'text-danger': threatNumber < cryptid.threatLevel, 'text-secondary': threatNumber > cryptid.threatLevel }"></i>
            </h2>
          </div>
          <div v-if="trackers.length">
            <h3>Trackers</h3>
            <div class="d-flex flex-wrap gap-2 mb-3">
              <span v-for="tracker in trackers" :key="tracker.trackedCryptidId">
                <ProfilePicture :profile="tracker" />
              </span>
            </div>
          </div>
          <div v-if="account">
            <button v-if="!foundTracker" @click="createTrackedCryptid()" class="btn btn-danger fs-2">
              Track the {{ cryptid.name }}
            </button>
            <button v-else @click="deleteTrackedCryptid()" class="btn btn-danger fs-2">
              UnTrack the {{ cryptid.name }}
            </button>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
h1,
h2,
h3 {
  text-shadow: 1px 1px var(--bs-light);
}
</style>