<script setup>
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';

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
  <h1>Cryptid Page!</h1>
</template>


<style lang="scss" scoped></style>