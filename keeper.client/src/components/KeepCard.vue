<template>
  <div class="">
    <div class="card"
         data-toggle="modal"
         data-target="#keepModal"
         @click="getById(keep.id),getProfile(keep.creatorId)"
    >
      <img class="card-img-top"
           :src="keep.img"
           alt="Card image cap"
      >
      <div class="card-img-overlay">
        <div class="card-body height"></div>
        <router-link class="link" :to="{name: 'Profile', params:{id: keep.creator.id }}">
          <div class="card-text d-flex ">
            <div class="col-9 text-center">
              <h5> {{ keep.name }}</h5>
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
  </div>
  <KeepModal />
</template>
<script>
import { profileService } from '../services/ProfileService'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
import { computed } from '@vue/runtime-core'
import Pop from '../utils/Notifier'

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      activeKeep: computed(() => AppState.activeKeep),
      activeProfile: computed(() => AppState.activeProfile),
      async getById(id) {
        try {
          await keepService.getById(id)
        } catch (error) {
          Pop.toast(error, 'not working')
        }
      },
      async getProfile(id) {
        try {
          await profileService.getProfile(id)
        } catch (error) {
          Pop.toast(error, 'not working')
        }
      }
    }
  }
}
</script>

<style scoped>
.pic{
  height: 5vh;
}
.height{

      height: 97%;
    margin-bottom: -2rem;

}
.link{
  text-decoration: none;
  color: #F0ECEE;
    -webkit-text-stroke: #0d0263;
    -webkit-text-stroke-width: medium;
}

</style>
