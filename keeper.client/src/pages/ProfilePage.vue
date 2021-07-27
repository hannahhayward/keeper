<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-2 text-center">
        <img :src="profile.picture" alt="profile picture">
      </div>
      <div class="col-8">
        <h3 class="text-left">
          {{ profile.name }}
        </h3>
        <p>Vaults:</p>
        <p>Keeps:</p>
      </div>
    </div>
    <div class="row">
      <div class="col-10 text-left">
        <h5>
          Vaults <i class="mdi mdi-plus-thick" data-toggle="modal" data-target="#vaultModal"></i>
        </h5>
      </div>
    </div>
    <div class="row">
      <VaultCard v-for="v in vaults" :key="v.id" :vault="v" />
    </div>
    <div class="row">
      <div class="col-10 text-left">
        <h5>Keeps <i class="mdi mdi-plus-thick" data-toggle="modal" data-target="#keepModal"></i></h5>
      </div>
    </div>
    <div class="row">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
    <!-- Vault Modal -->
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
            <label for="vaultTitle">Title</label>
            <input type="text" name="Title" id="newVaultTitle" class="form-control" placeholder="Title..." />
            <label for="vaultDescription">Description</label>
            <input type="text" name="Description" id="newVaultDescription" class="form-control" placeholder="Description..." />
            <div class="btn-group btn-group-toggle" data-toggle="buttons">
              <label class="btn btn-secondary active">
                <input type="radio" name="options" id="option1" checked> Private
              </label>
              <label class="btn btn-secondary">
                <input type="radio" name="options" id="option2"> Public
              </label>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
              <button type="button" class="btn btn-primary">
                Save changes
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- Keep Modal -->
    <div class="modal fade"
         id="keepModal"
         tabindex="-1"
         aria-labelledby="createKeepModal"
         aria-hidden="true"
         data-backdrop="static"
    >
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">
              New Keep
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <label for="keepName">Name</label>
            <input type="text" name="Name" id="newKeepName" class="form-control" placeholder="Name..." />
            <label for="keepImg">Img</label>
            <input type="text" name="Img" id="newKeepImg" class="form-control" placeholder="Img..." />
            <label for="keepDescription">Description</label>
            <input type="text" name="Description" id="newKeepDescription" class="form-control" placeholder="Description..." />
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
              <button type="button" class="btn btn-primary">
                Save changes
              </button>
            </div>
          </div>
        </div>
      </div>
      <!-- Keep Modal -->
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
// import { profileService } from '../services/ProfileService'
export default {
  setup(props) {
    const route = useRoute()
    onMounted(() => {
      try {
        logger.log(route.params.id, 'user id')
        vaultService.getVaultsByProfileId(route.params.id)
        keepService.getKeepsByProfileId(route.params.id)
      } catch (error) {
        logger.log('didnt get anything')
      }
    })
    return {
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.activeProfileKeeps),
      vaults: computed(() => AppState.activeProfileVaults)
    }
  }

}
</script>

<style>

</style>
