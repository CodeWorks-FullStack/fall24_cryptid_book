<script setup>
import { AppState } from '@/AppState.js';
import CryptidCard from '@/components/CryptidCard.vue';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const cryptids = computed(() => AppState.cryptids)

onMounted(() => {
  getAllCryptids()
})

async function getAllCryptids() {
  try {
    await cryptidsService.getAllCryptids()
  } catch (error) {
    Pop.meow(error)
    logger.error(error)
  }
}

</script>

<template>
  <div class="container">
    <section class="row hero my-3 align-items-center rounded border border-4 border-danger">
      <div class="col-12">
        <h1 class="kablammo-font text-danger ms-3">Cryptid Book</h1>
      </div>
    </section>

    <section class="row">
      <div v-for="cryptid in cryptids" :key="cryptid.id" class="col-md-3 mb-3">
        <CryptidCard :cryptid="cryptid" />
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss">
.hero {
  background-image: url(https://images.unsplash.com/photo-1509411273045-2920cee823be?q=80&w=2225&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  min-height: 50dvh;
  background-size: cover;
  background-position: center;

  h1 {
    text-shadow: 1px 1px var(--bs-light);
  }
}
</style>
