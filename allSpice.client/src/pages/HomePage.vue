<template>
  <div class="container-fluid  bg-color">

    <section class="row px-2">
      <div class="col-12  big-img p-3  mt-2 align-items-center">

        <h2 class="text-center text-light  pt-3">All-Spice</h2>
        <h4 class="text-center text-light  p-0"> Your guid for a tasty life</h4>
      </div>
    </section>

    <section class="row justify-content-center">
      <div class="d-flex justify-content-center ">
        <div class="move-up border border-2 border-light rounded bg-light
         ">

          <button class="btn text-dark ">Home</button>
          <button class="btn text-dark">My Recipes</button>
          <button class="btn text-dark">Favorites</button>
        </div>
      </div>

    </section>

    <section v-if="recipe" class="row  ">
      <div v-for="r in recipe" class="d-flex justify-content-around col-4   text-center">
        <div @click="setActiveRecipe(r.id)" class="img-fluid">

          <div data-bs-toggle="modal" data-bs-target="#appVueModal"
            class=" selectable m-1 bg-dark border border-2 rounded border-light  img-size"
            :style="`background-image: url(${r.img})`">
            <div>
              <h5 class="text-limit p-2"> <span class="">{{ r.title }}</span></h5>
            </div>
          </div>
        </div>
      </div>
    </section>

    <section class="row sticky-bottom justify-content-end">

      <div class="col-3  d-flex justify-content-end ">
        <button data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-success m-3"> Add Recipe
        </button>

      </div>
    </section>

  </div>
  <Modal id="exampleModal">
    <RecipeFormPage />
  </Modal>
</template>

<script>
import { onMounted, computed, ref } from "vue";
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
import { recipesService } from "../services/RecipesService"
import { AppState } from "../AppState";
import Modal from '../components/Modal.vue'
import RecipeFormPage from '../components/RecipeForm.vue'






export default {
  setup() {
    const filterBy = ref("");
    onMounted(() => {
      GetRecipes()
    })

    async function GetRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        logger.log(error);
        Pop.error(error.message)
      }
    }








    return {
      account: computed(() => AppState.account),
      recipe: computed(() => {
        if (filterBy.value == "") {
          return AppState.recipes;
        } else {
          return AppState.recipes.filter(r => r.category == filterBy.value);
        }
      }),
      activeRecipe: computed(() => AppState.activeRecipe),
      filterBy,



      async setActiveRecipe(recipeId) {
        try {
          await recipesService.getOneRecipe(recipeId)
        } catch (error) {
          logger.log(error.message)
        }
      }



    }
  },
  components: { Modal, RecipeFormPage }
}
</script>

<style scoped lang="scss">
.img-size {
  height: 40vh;
  width: 40vh;
  background-size: cover;
  background-image: center;
}

.text-limit {
  display: block;
  width: 9em;
  overflow: hidden;
  white-space: nowrap;
  text-overflow: ellipsis;
}

.big-img {
  border: 2px solid;
  border-radius: 5px;
  background-image: url('https://resources.healthydirections.com/resources/web/articles/sin/sin-heart-health-benefits-turmeric-cover.jpg');
  background-size: 100%;
  background-repeat: no-repeat;
  width: 100%;
  height: 25vh;

}

.bg-color {
  background-color: rgba(226, 102, 13, 0.648);
}

.move-up {
  transform: translateY(-3vh);
}
</style>
