<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import ModalWrapper from './components/ModalWrapper.vue';
import CryptidForm from './components/CryptidForm.vue';

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>

  <ModalWrapper modalId="cryptid-modal" modalTitle="Create a new Cryptid!">
    <CryptidForm />
  </ModalWrapper>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
