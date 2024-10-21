<script setup>
import { AppState } from '@/AppState.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const cryptid = computed(() => AppState.activeCryptid)
const route = useRoute()

onMounted(() => {
  getCryptidById()
})

async function getCryptidById() {
  try {
    await cryptidsService.getCryptidById(route.params.cryptidId)
  } catch (error) {
    Pop.meow(error)
    logger.error(error)
  }
}

</script>


<template>
  <div v-if="cryptid" class="container">
    <section class="row">
      <div class="col-md-4">
        <img :src="cryptid.imgUrl" :alt="cryptid.name" class="img-fluid">
      </div>
      <div class="col-md-8">
        <h1>{{ cryptid.name }}</h1>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped></style>