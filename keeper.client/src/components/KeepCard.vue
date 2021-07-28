<template>
  <div class="">
    <div class="card">
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
      <router-link :to="{name: 'Profile', params:{id: activeKeep.id}}">
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
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { computed } from '@vue/runtime-core'

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      activeKeep: computed(() => AppState.activeKeep),
      async getById(id) {
        try {
          await keepService.getById(id)
        } catch (error) {
          logger.log('not working')
        }
      },
      async getProfile(id) {
        try {
          await profileService.getProfile(id)
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
