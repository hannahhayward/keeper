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
        <p>Vaults: {{ vaults.length }}</p>
        <p>Keeps: {{ keeps.length }}</p>
      </div>
    </div>
    <div class="row">
      <div class="col-10 text-left">
        <h5>
          Vaults <i class="mdi mdi-plus-thick" data-toggle="modal" data-target="#vaultModal" v-if="state.account.id === profile.id"></i>
        </h5>
      </div>
      <CreateVaultModal />
    </div>
    <div class="row">
      <VaultCard v-for="v in vaults" :key="v.id" :vault="v" />
    </div>
    <div class="row">
      <div class="col-10 text-left">
        <h5>Keeps <i class="mdi mdi-plus-thick" data-toggle="modal" data-target="#keepModal" v-if="state.account.id === profile.id"></i></h5>
      </div>
      <CreateKeepModal />
    </div>
    <div class="row">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
export default {
  setup() {
    const route = useRoute()
    const state = reactive({
      account: AppState.account
    })
    onMounted(() => {
      try {
        vaultService.getVaultsByProfileId(route.params.id)
        keepService.getKeepsByProfileId(route.params.id)
        profileService.getProfile(route.params.id)
      } catch (error) {
        logger.log('didnt get anything')
      }
    })
    return {
      state,
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.activeProfileKeeps),
      vaults: computed(() => AppState.activeProfileVaults)
    }
  }

}
</script>

<style>

</style>
