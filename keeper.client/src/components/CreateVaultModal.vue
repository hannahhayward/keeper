<template>
  <div class="modal fade"
       id="vaultModal"
       tabindex="-1"
       aria-labelledby="createVaultModal"
       aria-hidden="true"
       data-backdrop="static"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Vault
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createVault" id="createVaultForm">
            <label for="vaultTitle">Title</label>
            <input type="text"
                   name="Title"
                   id="newVaultTitle"
                   class="form-control"
                   placeholder="Title..."
                   v-model="state.newVault.title"
                   @submit.prevent="createVault"
            />
            <label for="vaultDescription">Description</label>
            <input type="text"
                   name="Description"
                   id="newVaultDescription"
                   class="form-control"
                   placeholder="Description..."
                   v-model="state.newVault.description"
                   @submit.prevent="createVault"
            />
            <!-- TODO - ask harrsion about this -->
            <div class="btn-group btn-group-toggle" data-toggle="buttons">
              <label class="btn btn-secondary active">
                <input type="radio" name="options" id="option1" checked> Private
              </label>
              <label class="btn btn-secondary">
                <input type="radio" name="options" id="option2"> Public
              </label>
            </div>
            <div class="modal-footer">
              <button type="submit" class="btn btn-primary" @submit.prevent="createVault()">
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
import { vaultService } from '../services/VaultService'
import { logger } from '../utils/Logger'
export default {
  setup() {
    const state = reactive({
      newVault: AppState.newVault
    })
    return {
      state,
      createVault() {
        try {
          vaultService.createVault(state.newVault)
        } catch (error) {
          logger.log('could not create vault')
        }
      }
    }
  }

}
</script>

<style>

</style>
