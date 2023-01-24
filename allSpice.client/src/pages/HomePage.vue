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
        <div class="border border-2 border-light rounded ">

          <button class="btn ">Home</button>
          <button class="btn">My Recipes</button>
          <button class="btn">Favorites</button>
        </div>
      </div>

    </section>

    <section v-if="recipe" class="row  ">
      <div v-for="r in recipe" class="d-flex justify-content-around col-4   text-center">
        <div @click="setActiveRecipe(r.id)" class="img-fluid">
          <div data-bs-toggle="modal" data-bs-target="#exampleModal"
            class=" selectable m-1 bg-dark border border-2 rounded border-light  img-size"
            :style="`background-image: url(${r.img})`">
            <div>
              <h5 class="text-limit p-2"> <span class="">{{ r.title }}</span></h5>

            </div>
          </div>
        </div>
      </div>
    </section>

    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel"></h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div v-if="activeRecipe" class="modal-body">
            <img class="img-fluid" :src="activeRecipe.img" alt="">
          </div>
          <div class="modal-footer">

          </div>
        </div>
      </div>
    </div>


  </div>
</template>

<script>
import { onMounted, computed, ref } from "vue";
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
import { recipesService } from "../services/RecipesService"
import { AppState } from "../AppState";






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
  }
}
</script>

<style scoped lang="scss">
.img-size {
  height: 40vh;
  width: 40vh;
  object-fit: cover;
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
</style>
