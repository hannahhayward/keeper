<template>
  <div class="">
    <div class="card bg-dark">
      <img class="card-img-top"
           :src="keep.img"
           data-toggle="modal"
           data-target="#keepModal"
           alt="Card image cap"

           @click="getById(keep.id),getProfile(keep.creatorId)"
      >
      <h5 class="card-title">
        {{ keep.name }}
      </h5>
      <i v-if="vault.creatorId === account.id" class="mdi mdi-delete-outline" @click="deleteVaultKeep(keep)"></i>
      <router-link class="link" :to="{name: 'Profile', params:{id: keep.creator.id }}">
        <p class="card-text align-text-bottom">
          {{ keep.creator.name }}
          <img :src="keep.creator.picture"
               :alt="keep.creator.id"
               class="pic rounded-pill"
          />
        </p>
      </router-link>
    </div>
  </div>
  <KeepModal />
</template>
<script>
import { profileService } from '../services/ProfileService'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
import { computed } from '@vue/runtime-core'
import { vaultService } from '../services/VaultService'
import { logger } from '../utils/Logger'

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      activeKeep: computed(() => AppState.activeKeep),
      activeProfile: computed(() => AppState.activeProfile),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      async deleteVaultKeep(keep) {
        try {
          logger.log(keep, 'keep before service')
          const confirm = window.confirm('are you sure you wish to delete')
          logger.log(keep.id, 'keep id before service')
          if (confirm === true) {
            // TODO get this decrement to work
            // await keepService.getById(keep.id)
            // this.activeKeep -= 1
            // logger.log(this.activeKeep)
            // keepService.updateKeep(this.activeKeep.id, this.activeKeep)
            await vaultService.deleteVaultKeep(keep)
          }
        } catch (error) {
          window.alert(error)
        }
      },
      async getById(id) {
        try {
          await keepService.getById(id)
        } catch (error) {
          window.alert(error)
        }
      },
      async getProfile(id) {
        try {
          await profileService.getProfile(id)
        } catch (error) {
          window.alert(error)
        }
      }
    }
  }
}
</script>

<style scoped>
.fit{
 object-fit: contain;
}
.pic{
  height: 5vh;
}

.size{
  min-height: 20vh;
  max-height: 30vh;
}
.my-card{
  position: relative;
    display: flex;
    flex-direction: column;
    color: aliceblue;
    min-width: 0;
    word-wrap: break-word;
    background-color: #010208ba;
    background-clip: border-box;
    border: 1px solid rgba(0, 0, 0, 0.125);
    border-radius: 0.25rem;
    height: fit-content;
    width: fit-content;
    padding: 0%;
}

</style>
