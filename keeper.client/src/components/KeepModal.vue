<template>
  <div class="modal fade "
       id="keepModal"
       tabindex="-1"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-size">
        <div class="header bg-dark height">
          <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close" @click="updateKeep(activeKeep.id)">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body h-100 bg-dark">
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
            <div class="col-6"></div>
            <div class="col-6 text-right d-flex ">
              <div class="align">
                <router-link class="link" style="text-decoration: none; color: inherit" :to="{name: 'Profile', params:{id: creator.id }}">
                  {{ creator.name }}
                </router-link>
                <div v-if="account.id === activeKeep.creatorId" class="text-center">
                  <i class="mdi mdi-delete-outline" @click="deleteKeep(activeKeep.id)"></i>
                </div>
              </div>
              <div class="pl-2">
                <router-link class="link" :to="{name: 'Profile', params:{id: creator.id }}">
                  <img :src="creator.picture" alt="" class="rounded-pill">
                </router-link>
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
import { vaultService } from '../services/VaultService'
import { keepService } from '../services/KeepService'
import Pop from '../utils/Notifier'
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
          AppState.newVaultKeep.vaultId = body
          AppState.newVaultKeep.creatorId = AppState.activeKeep.creatorId
          AppState.newVaultKeep.keepId = AppState.activeKeep.id
          vaultService.createVaultKeep(AppState.newVaultKeep)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      },
      async deleteKeep(id) {
        try {
          keepService.deleteKeep(id)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      },
      async updateKeep(keep) {
        try {
          keep.views += 1
          keepService.updateKeep(keep)
        } catch (error) {
          Pop.toast(error, 'error')
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
    height: 2rem;
}
.modal-img{
  object-fit: contain;
  object-position: center;
  width: -webkit-fill-available;}
.header{
display: flex;
    justify-content: flex-end;
    padding-right: 1rem;

  }
  .link{
  text-decoration: none;
  color: #F0ECEE;
    -webkit-text-stroke: #0d0263;
    -webkit-text-stroke-width: .05px;
}

</style>
