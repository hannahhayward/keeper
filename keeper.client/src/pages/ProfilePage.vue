<template>
  <div class="container-fluid bg-color text-light">
    <div class="row py-3 shadow">
      <div class="col-lg-2 text-center pl-5">
        <img :src="profile.picture" alt="profile picture" class="profile-pic">
      </div>
      <div class="col-lg-8">
        <h3 class="text-left">
          {{ profile.name }}
        </h3>
        <p>
          Vaults: {{ vaults.length }}
        </p>
        <p class="pt-3">
          Keeps: {{ keeps.length }}
        </p>
      </div>
    </div>
    <div class="row py-4">
      <div class="col-lg-11 m-auto text-left">
        <h5>
          Vaults <i class="mdi mdi-plus-thick" data-toggle="modal" data-target="#vaultModal" v-if="account.id === profile.id"></i>
        </h5>
      </div>
      <p v-if="vaults.length == 0" class="text-center">
        <img src="https://i.pinimg.com/originals/5f/93/49/5f934966a1d20bae1909c9ef2278bd4c.gif" alt="sad cat" class="no-content">
        no vaults here yet
      </p>
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
      <p v-if="keeps.length == 0" class="text-center">
        <img src="https://i.pinimg.com/originals/5f/93/49/5f934966a1d20bae1909c9ef2278bd4c.gif" alt="sad cat" class="no-content">
        no keeps here yet
      </p>
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
        await profileService.getProfile(route.params.id)
        await keepService.getKeepsByProfileId(route.params.id)
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
.profile-pic{
max-height: 8rem;
}
.shadow{
  box-shadow: 0 0 0 2em #022933;;
}
.no-content{
height: 10rem;
}

</style>
