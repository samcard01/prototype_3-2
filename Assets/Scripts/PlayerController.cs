using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // VARIABLE VERS UNE INSTANCE DE LA CLASSE RigidBody
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    private Animator playerAnim;
    public ParticleSystem explosionParticle ;
    public ParticleSystem dirtParticle ;
    //Créer des variables pour les sons
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()  {
        playerRb = GetComponent<Rigidbody>();
        //Aller chercher le component de l'Animator du joueur
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        //Aller chercher l'Audio Source du player
        playerAudio = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()  {
        // DETECTER SI LA TOUCHE ESPACE EST APPUYÉE ET EST-CE QUE LE PERSONNAGE EST DÉCLARÉ AU SOL?
        if ( Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false) {
            // SI OUI, IMPRIMER LE MESSAGE "JUMP"
            Debug.Log("JUMP");
            // AJOUTER UNE FORVE VERS LE HAUT 
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
            // DÉCLARER QUE LE PERSONNAGE N'EST PLUS AU SOL
            isOnGround = false;
            //Déclenche moi JumpTrig quand c'est le temps de sauter
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            //Quand saut joue une fois le son de saut
            playerAudio.PlayOneShot(jumpSound, 1f);
        }   
    }

    public bool gameOver = false;

    // LORSQUE LE PERSONNAGE RENTRE EN COLLISION...
    void OnCollisionEnter(Collision collision) {
        // ... AVEC LE SOL : DÉCLARER QU'IL EST AU SOL (isOnGround = true)
        if ( collision.gameObject.CompareTag("Ground") ) {
            isOnGround = true;
            dirtParticle.Play();
            // ... AVEC UN OBSTACLE : DÉCLARER LE «GAME OVER» (gameOver = true)
        } else if ( collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("Game Over");
            gameOver = true;
            //Changer la valeur du booléen Death et le remplacer par vrai
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            //Quand collision joue une fois le son de crash
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }


}

