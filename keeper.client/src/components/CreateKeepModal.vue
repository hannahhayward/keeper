<template>
  <div class="modal fade"
       id="createKeepModal"
       tabindex="-1"
       aria-labelledby="createKeepModal"
       aria-hidden="true"
       data-backdrop="static"
  >
    <div class="modal-dialog">
      <div class="modal-content bg-dark">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Keep
          </h5>
          <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createKeep">
            <label for="keepName">Name</label>
            <input type="text"
                   name="Name"
                   id="newKeepName"
                   class="form-control"
                   placeholder="Name..."
                   v-model="state.newKeep.name"
            />
            <label for="keepImg">Img</label>
            <input type="text"
                   name="Img"
                   id="newKeepImg"
                   class="form-control"
                   placeholder="Img..."
                   v-model="state.newKeep.img"
            />
            <label for="keepDescription">Description</label>
            <input type="text"
                   name="Description"
                   id="newKeepDescription"
                   class="form-control"
                   placeholder="Description..."
                   v-model="state.newKeep.description"
            />
            <div class="modal-footer">
              <button type="submit" class="btn btn-primary">
                Create
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
export default {
  setup() {
    const state = reactive({
      newKeep: AppState.newKeep
    })
    return {
      state,
      async createKeep() {
        try {
          await keepService.createKeep(state.newKeep)
        } catch (error) {
          window.alert(error, 'could not create keep')
        }
      }
    }
  }
}
</script>

<style>

</style>
