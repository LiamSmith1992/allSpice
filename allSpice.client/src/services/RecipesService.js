import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"



class RecipesService {

  async getRecipes() {
    try {
      const res = await api.get('api/recipes')
      logger.log('recipes', res.data)
      AppState.recipes = res.data
    } catch (error) {
      logger.log(error.message)
    }
  }

  async getOneRecipe(recipeId) {
    const res = await api.get('api/recipes/' + recipeId)
    logger.log(res.data)
    AppState.activeRecipe = res.data
  }

  async createRecipe(body) {
    const res = await api.post('api/recipes', body)
    logger.log('create recipe', res.data)
    AppState.recipes.push(res.data)
    AppState.activeRecipe = res.data

  }

}





export const recipesService = new RecipesService()