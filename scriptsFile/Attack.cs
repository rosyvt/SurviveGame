using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        public GameObject gunL;
        public GameObject gunR;
        public float comboTimeout;
        Animator anim;
        GunAtkControl gunAtkControl;
        int atk = 0;
        bool allowAtk = true;
        bool isAttacking = false;
        IEnumerator comboTimoutCoroutine;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            gunAtkControl = GetComponent<GunAtkControl>();
            gunL.SetActive(false);
            gunR.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Z) && allowAtk)
            {
                if (comboTimoutCoroutine != null)
                {
                    StopCoroutine(comboTimoutCoroutine);
                }
                if (anim.GetInteger("AttackType") == 1 && gunAtkControl.IsOverHeat() == false)
                {
                    atk++;
                    isAttacking = true;
                    atk = atk > 2 ? 1 : atk;
                    if (anim.GetInteger("GunAtk") != 3)
                    {
                        anim.SetInteger("GunAtk", atk);
                        allowAtk = false;
                    }
                }
                else if (anim.GetInteger("AttackType") == 2)
                {
                    atk++;
                    isAttacking = true;
                    atk = atk > 4 ? 1 : atk;
                    anim.SetInteger("SpellAtk", atk);
                    allowAtk = false;
                }
                else
                {
                    atk++;
                    isAttacking = true;
                    atk = atk > 3 ? 1 : atk;
                    anim.SetInteger("Attack", atk);
                    allowAtk = false;
                }
            }
        }

        public bool IsAttacking()
        {
            return isAttacking;
        }

        public void ResetAtk()
        {
            allowAtk = true;
            isAttacking = false;
            atk = 0;
            anim.SetInteger("Attack", 0);
            anim.SetInteger("SpellAtk", 0);
            anim.SetInteger("GunAtk", 0);
        }

        void Done(string type = "")
        {
            allowAtk = true;
            isAttacking = false;
            anim.SetInteger("Attack", 0);
            anim.SetInteger("SpellAtk", 0);
            if (anim.GetInteger("GunAtk") != 3 || type == "dual")
            {
                anim.SetInteger("GunAtk", 0);
            }
            if (comboTimoutCoroutine != null)
            {
                StopCoroutine(comboTimoutCoroutine);
            }
            comboTimoutCoroutine = ComboTimeoutCoroutine();
            StartCoroutine(comboTimoutCoroutine);
        }

        IEnumerator ComboTimeoutCoroutine()
        {
            yield return new WaitForSeconds(comboTimeout);
            ResetAtk();
        }
    }
}
