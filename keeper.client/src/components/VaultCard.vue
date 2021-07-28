<template>
  <div class="card" @click="getById(vault.id)">
    <router-link :to="{name: 'Vault', params:{id: vault.id}}" v-if="vault.isPrivate == false">
      <div class="row d-flex">
        <div class="card-body col-9">
          <h5 class="card-text" data-toggle="modal" data-target="#exampleModal">
            {{ vault.name }}
          </h5>
          <p>
            {{ vault.description }}
          </p>
        </div>
      </div>
    </router-link>
  </div>
</template>
<script>
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { computed } from '@vue/runtime-core'
import { vaultService } from '../services/VaultService'

export default {
  props: { vault: { type: Object, required: true } },
  setup(props) {
    return {
      activeVault: computed(() => AppState.activeVault),
      async getById(id) {
        try {
          await vaultService.getById(id)
        } catch (error) {
          logger.log('not working')
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
