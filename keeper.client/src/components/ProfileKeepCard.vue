<template>
  <div class="card" data-toggle="modal" data-target="#exampleModal" @click="getById(keep.id)">
    <div class="card-container">
      <img class="card-img-top" :src="keep.img" alt="Card image cap">
      <div class="card-img-overlay">
        <h5 class="card-title">
          {{ keep.name }}
        </h5>
        <router-link :to="{name: 'Profile', params:{id: keep.creator.id}}">
          <p class="card-text">
            {{ keep.creator.name }}
            <img :src="keep.creator.picture"
                 :alt="keep.creator.id"
                 class="pic rounded-pill"
            />
          </p>
        </router-link>
      </div>
    </div>
  </div>
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
