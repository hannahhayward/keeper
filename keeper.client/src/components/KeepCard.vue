<template>
  <div class="col-3 my-card" @click="getById(keep.id)">
    <img :src="keep.img" class="fit" :alt="keep.id" data-toggle="modal" data-target="#keepModal">
    <div class="row d-flex">
      <div class="card-body col-9">
        <h5 class="card-text" data-toggle="modal" data-target="#exampleModal">
          {{ keep.name }}
        </h5>
      </div>
      <div class="col-3 mt-2">
        <div>
          <router-link :to="{name: 'Profile', params:{id: keep.creator.id}}">
            <img :src="keep.creator.picture"
                 :alt="keep.creator.id"
                 class="pic rounded-pill"
            >
          </router-link>
        </div>
      </div>
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
