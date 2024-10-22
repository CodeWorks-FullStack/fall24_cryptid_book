<script setup>
import { AppState } from '@/AppState.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { trackedCryptidsService } from '@/services/TrackedCryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted, onUnmounted, watch } from 'vue';
import { useRoute } from 'vue-router';

const cryptid = computed(() => AppState.activeCryptid)
const route = useRoute()

onMounted(() => {
  getCryptidById()
})

watch(cryptid, () => {
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

async function createTrackedCryptid() {
  try {
    const trackedCryptidData = { cryptidId: route.params.cryptidId }
    await trackedCryptidsService.createTrackedCryptid(trackedCryptidData)
  } catch (error) {
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
          <div>
            <button @click="createTrackedCryptid()" class="btn btn-danger fs-2">Track the {{ cryptid.name }}</button>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
h1,
h2 {
  text-shadow: 1px 1px var(--bs-light);
}
</style>