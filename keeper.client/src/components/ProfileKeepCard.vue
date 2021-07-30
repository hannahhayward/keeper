<template>
  <div class="card"
       data-toggle="modal"
       data-target="#keepModal"
       @click="getById(keep.id)"
  >
    <img class="card-img-top" :src="keep.img" alt="Card image cap">
    <div class="card-img-overlay">
      <div class="card-body height"></div>
      <router-link class="link" :to="{name: 'Profile', params:{id: keep.creator.id }}">
        <div class="card-text d-flex">
          <div class="col-9 text-center">
            <h6> {{ keep.name }}</h6>
          </div>
          <div class="col-2">
            <img :src="keep.creator.picture"
                 :alt="keep.creator.id"
                 class="pic rounded-pill"
            />
          </div>
        </div>
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

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      activeKeep: computed(() => AppState.activeKeep),
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
.link{
  text-decoration: none;
  color: #F0ECEE;
    -webkit-text-stroke: #535353;
    -webkit-text-stroke-width: thin;
}
.height{
      height: 97%;
    margin-bottom: -2rem;
}
.card-img-overlay
    {position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    padding: 1.25rem;
    border-radius: calc(0.25rem - 1px);
    background-image: linear-gradient(#ff000000, #21211f);}

</style>
