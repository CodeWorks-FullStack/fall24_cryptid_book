<script setup>
import { Cryptid } from '@/models/Cryptid.js';
import ProfilePicture from './ProfilePicture.vue';

defineProps({
  cryptid: { type: Cryptid, required: true }
})
</script>


<template>
  <div class="position-relative">
    <img :src="cryptid.imgUrl" :alt="'Spooky picture of the ' + cryptid.name"
      class="cryptid-img rounded border border-3 border-danger shadow">
    <h2 class="kablammo-font text-danger m-2">{{ cryptid.name }}</h2>
    <span class="m-2">
      <ProfilePicture :profile="cryptid.discoverer" />
    </span>
  </div>
</template>


<style lang="scss" scoped>
.cryptid-img {
  width: 100%;
  aspect-ratio: 1/1;
  object-fit: cover;
}

h2 {
  font-size: 3rem;
  position: absolute;
  top: 0;
  text-shadow: 1px 1px var(--bs-light);
}

span {
  position: absolute;
  bottom: 0;
  right: 0;
}
</style>