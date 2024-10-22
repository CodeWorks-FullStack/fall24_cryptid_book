<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '@/utils/Pop.js';
import { trackedCryptidsService } from '@/services/TrackedCryptidsService.js';
import CryptidCard from '@/components/CryptidCard.vue';

const account = computed(() => AppState.account)
const cryptids = computed(() => AppState.myTrackedCryptidCryptids)

onMounted(() => { getCryptidsIAmTracking() })

async function getCryptidsIAmTracking() {
  try {
    await trackedCryptidsService.getCryptidsIAmTracking()
  } catch (error) {
    Pop.error(error)
  }
}

async function deleteTrackedCryptid(trackedCryptidId) {
  try {
    const yes = await Pop.confirm()
    if (!yes) return
    await trackedCryptidsService.deleteTrackedCryptid(trackedCryptidId)
  } catch (error) {
    Pop.meow(error)
  }
}

</script>

<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <h1 class="kablammo-font">Tracked Cryptids</h1>
      </div>
    </div>
    <div class="row">
      <div v-for="cryptid in cryptids" :key="cryptid.trackedCryptidId" class="col-4">
        <CryptidCard :cryptid="cryptid" />
        <button class="btn btn-danger" @click="deleteTrackedCryptid(cryptid.trackedCryptidId)">Untrack the
          cryptid</button>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
