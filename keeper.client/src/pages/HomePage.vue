<template>
  <div class="container-fluid d-flex bg-color text-light">
    <div class="row">
      <div class="card-columns ">
        <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, watchEffect } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import Pop from '../utils/Notifier'
import { profileService } from '../services/ProfileService'

export default {
  name: 'Home',
  setup() {
    const userId = AppState.account.id
    const state =
    ({ profile: computed(() => AppState.account) })
    onMounted(async() => {
      try {
        await vaultService.getUserVaults(userId)
        await keepService.getKeeps()
        debugger
        await profileService.getProfile(userId)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      state,
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.userVaults)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}

</style>
