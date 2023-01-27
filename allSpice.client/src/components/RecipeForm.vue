<template>
  <div class="component">
    <section class="row">

      <form @submit.prevent="createRecipe()">

        <div class="m-2 col-11 ">
          <h2 class="m-3">Create Recipe</h2>
          <div class="m-3">
            <label for="exampleFormControlInput1" class="form-label outline rounded bg-info p-2">Recipe Name</label>
            <input v-model="editable.title" type="text" class="form-control" id="exampleFormControlInput1"
              placeholder="Recipe Name">
          </div>
          <div class="m-3">
            <label for="exampleFormControlInput1" class="form-label border bg-info p-2 rounded">Recipe Photo</label>
            <input v-model="editable.img" type="url" class="form-control" id="exampleFormControlInput1"
              placeholder="Image Address">
          </div>
          <div class="m-3">

            <label for="dropdown" class="outline mb-2 p-2 bg-info rounded "> Category</label>
            <select v-model="editable.category" class="form-select" aria-label="Default select example" id="dropdown">
              <option selected>Category</option>
              <option value="1">breakfast</option>
              <option value="2">lunch</option>
              <option value="3">dinner</option>
            </select>
          </div>

          <div class="m-3 col-12">
            <div class="mb-3">
              <label for="exampleFormControlTextarea1" class="form-label border bg-info p-2 rounded">
                Instructions</label>
              <textarea v-model="editable.instructions" class="form-control" id="exampleFormControlTextarea1"
                rows="3"></textarea>
            </div>
            <div class="text-end">

              <button class="btn btn-success">Create</button>
            </div>
            <p>
            <h2 class="text-danger">NOTE:</h2> Ingredients once the recipe is built</p>
          </div>
        </div>
      </form>
    </section>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from "../utils/Logger";
import { recipesService } from "../services/RecipesService";

import { Modal } from "bootstrap";

export default {



  setup() {
    const editable = ref({})




    return {
      editable,
      async createRecipe() {
        try {
          const recipe = await recipesService.createRecipe(editable.value)
          Modal.getOrCreateInstance('#exampleModal').hide()
          Modal.getOrCreateInstance('#appVueModal').show()
          editable.value = {}

        } catch (error) {
          logger.log(error.message)
        }
      }


    }
  }
};
</script>


<style lang="scss" scoped>

</style>