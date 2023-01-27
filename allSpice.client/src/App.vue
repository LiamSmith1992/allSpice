<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">

    <Modal id="appVueModal">
      <RecipeDetails />
    </Modal>


  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Modal from "./components/Modal.vue"
import RecipeDetails from "./components/RecipeDetails.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)

    }
  },
  components: { Navbar, Modal, RecipeDetails }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
