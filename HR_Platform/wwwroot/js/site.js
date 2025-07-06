import { getSkills, setupSkillListeners } from './skills.js';
import { getCandidates, setupCandidateListeners } from './candidates.js';

window.onload = function () {
    getCandidates();
    getSkills();
}

setupSkillListeners();
setupCandidateListeners();

