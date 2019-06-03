import os
import server
import threading

pokemon_images = ["python classify.py --model pokedex.model --labelbin lb.pickle --image examples/charmander_counter.png", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/bulbasaur_plush.png", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/pikachu_meme.png", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/pikachu_toy.png"]


def classify_pokemon():

    os.system(pokemon_images[2])



if __name__ == "__main__":
    t1 = threading.Thread(target = server.Connection.server)
    t2 = threading.Thread(target = classify_pokemon)

    t1.start()
    t2.start()