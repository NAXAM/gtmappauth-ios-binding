libs=(GTMAppAuth)
for lib in "${libs[@]}"
do
sharpie bind -sdk appletvos -n $lib -o ./frameworks/${lib} ./frameworks/${lib}/include/*.h
done

# sharpie bind -sdk appletvos -n AppAuth -o ./frameworks/AppAuth ./frameworks/AppAuth/include/*.h


