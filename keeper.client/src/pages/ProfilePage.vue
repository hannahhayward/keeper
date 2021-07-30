<template>
  <div class="container-fluid bg-color text-light">
    <div class="row py-1">
      <div class="col-lg-2 text-center pl-5">
        <img :src="profile.picture" alt="profile picture">
      </div>
      <div class="col-lg-8">
        <h3 class="text-left">
          {{ profile.name }}
        </h3>
        <p>Vaults: {{ vaults.length }}</p>
        <p>Keeps: {{ keeps.length }}</p>
      </div>
    </div>
    <div class="row py-1">
      <div class="col-lg-11 m-auto text-left">
        <h5>
          Vaults <i class="mdi mdi-plus-thick" data-toggle="modal" data-target="#vaultModal" v-if="account.id === profile.id"></i>
        </h5>
      </div>
      <CreateVaultModal />
    </div>
    <div class="row py-1">
      <div class="col-lg-11 m-auto">
        <div class="card-columns">
          <VaultCard v-for="v in vaults" :key="v.id" :vault="v" />
        </div>
      </div>
    </div>
    <div class="row py-1">
      <div class="col-lg-11 m-auto text-left">
        <h5>Keeps <i class="mdi mdi-plus-thick" data-toggle="modal" data-target="#createKeepModal" v-if="account.id === profile.id"></i></h5>
      </div>
      <CreateKeepModal />
    </div>
    <div class="row py-1">
      <div class="col-lg-11 m-auto">
        <div class="card-columns">
          <ProfileKeepCard v-for="k in keeps" :key="k.id" :keep="k" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'

export default {
  setup() {
    const route = useRoute()
    onMounted(async() => {
      try {
        await keepService.getKeepsByProfileId(route.params.id)
        await profileService.getProfile(route.params.id)
        await vaultService.getVaultsByProfileId(route.params.id)
      } catch (error) {
        window.alert(error)
      }
    })
    return {
      profile: computed(() => AppState.activeProfile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.activeProfileKeeps),
      vaults: computed(() => AppState.activeProfileVaults)
    }
  }

}
</script>

<style>

</style>
