<script setup>
import { Cryptid } from '@/models/Cryptid.js';

defineProps({
  cryptid: { type: Cryptid, required: true }
})
</script>


<template>
  <h2>{{ cryptid.name }}</h2>
</template>


<style lang="scss" scoped></style>