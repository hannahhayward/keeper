<template>
  <div class="modal fade"
       id="vaultKeepModal"
       tabindex="-1"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-size">
        <!-- <div class="modal-header">
          <p class="text-right">
            <i class="mdi mdi-close " @click="updateKeep(activeKeep)" data-dismiss="modal"></i>
          </p>
        </div> -->
        <div class="modal-body h-100">
          <div class="row text-right">
            <img class="modal-img h-50 w-50 col-6" :src="activeKeep.img" alt="">
            <div class="col-6 text-center">
              <div class="col-10">
                <h6>
                  {{ activeKeep.name }}
                </h6>
                <p class="p-0">
                  {{ activeKeep.description }}
                </p>
                <p class="m-0 d-flex justify-content-around">
                  <i class="mdi mdi-eye-outline"></i>
                  <i class="mdi mdi-pin-outline"></i>
                </p>
                <span class="m-0 d-flex justify-content-around">
                  <p>{{ activeKeep.views }}</p>
                  <p>{{ activeKeep.keeps }}</p>
                </span>
                <div class="dropdown text-center">
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
          <div class="row">
            <div class="col-3" v-if="account.id === activeKeep.creatorId">
              <i class="mdi mdi-delete-outline" @click="deleteKeep(activeKeep.id)"></i>
            </div>
            <div class="col-3">
              <i class="mdi mdi-close " @click="updateKeep(activeKeep)" data-dismiss="modal"></i>
            </div>
            <div class="col-3 d-flex ">
              <p class="align">
                {{ creator.name }}
              </p>
            </div>
            <div class="col-3 d-flex justify-content-end">
              <img :src="creator.picture" alt="" class="rounded-pill ">
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
import { keepService } from '../services/KeepService'
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
      account: computed(() => AppState.account),
      creator: computed(() => AppState.activeProfile),
      async addKeep(body) {
        try {
          // debugger
          AppState.newVaultKeep.vaultId = body
          AppState.newVaultKeep.creatorId = AppState.activeKeep.creatorId
          AppState.newVaultKeep.keepId = AppState.activeKeep.id
          vaultService.createVaultKeep(AppState.newVaultKeep)
          AppState.activeKeep.keeps += 1
          keepService.updateKeep(AppState.activeKeep)
        } catch (error) {
          logger.log(error, 'couldnt add to your vault')
        }
      },
      async deleteKeep(id) {
        try {
          keepService.deleteKeep(id)
        } catch (error) {
          logger.log(error, 'could not delete')
        }
      },
      async updateKeep(keep) {
        try {
          keep.views += 1
          keepService.updateKeep(keep)
        } catch (error) {
          logger.log(error, 'nah')
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
.align{
  align-self: flex-end;
}
.rounded-pill{
    border-radius: 171rem !important;
    height: 3rem;
}
.modal-img{
  object-fit: contain;
  object-position: center;
  width: -webkit-fill-available;}

</style>
