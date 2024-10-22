<script setup>
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';

const origins = [
  'extra-terrestrial',
  'subterranean',
  'aquatic',
  'lab-grown',
  'suburban',
  'cross-dimensional'
]
const sizes = ['rodent', 'humanoid', 'giant', 'colossal']

const editableCryptidData = ref({
  name: '',
  imgUrl: '',
  threatLevel: 0,
  origin: '',
  size: ''
})

async function createCryptid() {
  try {
    await cryptidsService.createCryptid(editableCryptidData.value)
    Modal.getInstance('#cryptid-modal').hide()
    editableCryptidData.value = {
      name: '',
      imgUrl: '',
      threatLevel: 0,
      origin: '',
      size: ''
    }
  } catch (error) {
    Pop.meow(error)
    logger.error(error)
  }
}
</script>


<template>
  <form @submit.prevent="createCryptid()">
    <div class="form-floating mb-3">
      <input v-model="editableCryptidData.name" type="text" class="form-control" id="cryptid-name"
        placeholder="Name of Cryptid" maxlength="255" required>
      <label for="cryptid-name">Name of Cryptid</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="editableCryptidData.imgUrl" type="url" class="form-control" id="cryptid-img-url"
        placeholder="Image of Cryptid" maxlength="3000" required>
      <label for="cryptid-img-url">Image of Cryptid</label>
    </div>
    <div class="mb-3">
      <label for="cryptid-threat-level" class="form-label">Threat Level {{ editableCryptidData.threatLevel }}</label>
      <input v-model="editableCryptidData.threatLevel" type="range" class="form-range" id="cryptid-threat-level" min="0"
        max="10" required>
    </div>
    <div class="mb-3">
      <div class="container">
        <div class="row">
          <div class="col-md-6 mb-3 mb-md-0">
            <div class="form-floating">
              <select v-model="editableCryptidData.origin" class="form-select text-capitalize" id="cryptid-origin"
                aria-label="Select an origin" required>
                <option selected disabled value="">Select an origin</option>
                <option v-for="origin in origins" :key="origin" class="text-capitalize" :value="origin">{{ origin }}
                </option>
              </select>
              <label for="cryptid-origin">Cryptid Origin</label>
            </div>
          </div>
          <div class="col-md-6">
            <div class="form-floating">
              <select v-model="editableCryptidData.size" class="form-select text-capitalize" id="cryptid-size"
                aria-label="Select a size" required>
                <option selected disabled value="">Select a size</option>
                <option v-for="size in sizes" :key="size" class="text-capitalize" :value="size">{{ size }}
                </option>
              </select>
              <label for="cryptid-size">Cryptid Size</label>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="text-end">
      <button class="btn btn-danger" type="submit">Submit</button>
    </div>
  </form>
</template>


<style lang="scss" scoped>
.form-range {
  outline: unset !important;
}
</style>