<template>
  <div class="container-fluid bg-color text-light">
    <div class="row py-3 shadow">
      <div class="col-10 m-auto">
        <h4>{{ vault.name }}</h4>
        <p>{{ vault.description }}</p>
        <router-link class="link" :to="{name: 'Profile', params:{id: vault.creatorId }}">
          <i class="mdi mdi-delete-outline" v-if="vault.creatorId === account.id" @click="deleteVault(vault.id)"></i>
        </router-link>
      </div>
    </div>
    <div class="row py-5 ">
      <div class="col-lg-10 m-auto">
        <p v-if="keeps.length == 0" class="text-center">
          There is no keeps in this vault yet
          <img src="https://i.pinimg.com/originals/5f/93/49/5f934966a1d20bae1909c9ef2278bd4c.gif" alt="sad dino">
        </p>
      </div>
    </div>
    <div class="row">
      <div class="col-lg-10 m-auto">
        <div class="card-columns " v-if="keeps.length > 0">
          <VaultKeepCard v-for="k in keeps" :key="k.id" :keep="k" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import { AppState } from '../AppState'
import { router } from '../router'

export default {
  setup() {
    const route = useRoute()

    onMounted(async() => {
      try {
        await keepService.getKeepsByVaultId(route.params.id)
        await vaultService.getById(route.params.id)
      } catch (error) {
        window.alert(error)
        router.push({ name: 'Home' })
      }
    })
    watchEffect(async() => {
      try {
        await vaultService.getById(route.params.id)
      } catch (error) {
        window.alert(error)
      }
    })
    return {
      deleteVault(id) {
        try {
          const confirm = window.confirm('are you sure you wish to delete')
          if (confirm === true) {
            vaultService.deleteVault(id)
          }
        } catch (error) {
          window.alert(error)
        }
      },
      route,
      keeps: computed(() => AppState.activeVaultKeeps),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account)
    }
  }

}
</script>

<style>
.shadow{
  box-shadow: 0 0 0 2em #022933;;
}

</style>
