<template>




  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
  <h2>this is the modal</h2>
  <div v-if="activeRecipe" class="modal-body"> -->
    <img class="img-fluid" :src="activeRecipe.img" alt="">
  </div>







</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Modal from '../components/Modal.vue'
export default {
  setup() {
    return {
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  },
  components: { Modal }
};
</script>


<style lang="scss" scoped>

</style>