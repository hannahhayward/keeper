<template>
  <div class="modal fade"
       id="vaultModal"
       tabindex="-1"
       aria-labelledby="createVaultModal"
       aria-hidden="true"
       data-backdrop="static"
  >
    <div class="modal-dialog ">
      <div class="modal-content bg-dark">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Vault
          </h5>
          <button type="button" class="text-light close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createVault" id="createVaultForm">
            <div class="row">
              <div class="col-12">
                <label for="vaultTitle">Title</label>
                <input type="text"
                       name="Title"
                       id="newVaultTitle"
                       class="form-control"
                       placeholder="Title..."
                       v-model="state.newVault.title"
                       @submit.prevent="createVault"
                />
              </div>
            </div>
            <div class="row">
              <div class="col-12">
                <label for="vaultDescription">Description</label>
                <input type="text"
                       name="Description"
                       id="newVaultDescription"
                       class="form-control"
                       placeholder="Description..."
                       v-model="state.newVault.description"
                       @submit.prevent="createVault"
                />
              </div>
            </div>
            <div class="row">
              <div class="col-12 pt-2">
                <label class="switch">
                  <input type="checkbox" @click="state.newVault.isPrivate != state.newVault.isPrivate" v-model="state.newVault.isPrivate">
                  <span class="slider round"></span>
                </label>
                <label for="isPrivate" class="px-2">Private</label>
              </div>
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
import Pop from '../utils/Notifier'
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
          Pop.toast(error, 'error')
        }
      }
    }
  }

}
</script>

<style>
/* The switch - the box around the slider */
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

/* Hide default HTML checkbox */
.switch input {
  opacity: 0;
  width: 0;
  height: 0;
}

/* The slider */
.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}

</style>
