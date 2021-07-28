<template>
  <div class="modal fade"
       id="keepModal"
       tabindex="-1"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-size">
        <div class="modal-body h-100">
          <div class="row">
            <img class="modal-img h-50 w-50 col-6" :src="activeKeep.img" alt="">
            <div class="col-6 text-center">
              <h6>
                {{ activeKeep.name }}
              </h6>
              <p>
                {{ activeKeep.description }}
              </p>
              <div class="dropdown">
                <button class="btn btn-info dropdown-toggle"
                        type="button"
                        id="vaultDropdownMenu"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                >
                  Add to a vault
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <div class="dropdown-option" v-for="v in vaults" :key="v.id" href="#" @click="addKeep(v.id)">
                    {{ v.name }}
                    <div class="dropdown-divider"></div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { vaultService } from '../services/VaultService'
export default {
  setup() {
    const state = reactive({
      profile: AppState.account,
      vaultKeep: AppState.newVaultKeep
    })
    return {
      state,
      activeKeep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.userVaults),
      async addKeep(body) {
        try {
          // debugger
          AppState.newVaultKeep.vaultId = body
          AppState.newVaultKeep.creatorId = AppState.activeKeep.creatorId
          AppState.newVaultKeep.keepId = AppState.activeKeep.id
          vaultService.createVaultKeep(AppState.newVaultKeep)
        } catch (error) {
          logger.log(error, 'couldnt add to your vault')
        }
      }
    }
  }
}
</script>

<style>
.modal-size{
  position: relative;
    display: flex;
    flex-direction: column;
    width: auto;
    height: auto;
    pointer-events: auto;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid rgba(0, 0, 0, 0.2);
    border-radius: 0.3rem;
    outline: 0;
}
.modal-img{
  object-fit: contain;
  object-position: center;
  width: -webkit-fill-available;}

</style>
