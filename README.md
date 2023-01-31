# DataPreprocessing1
Given an input data in csv, perform data preprocessing

https://www.youtube.com/watch?v=k2P_pHQDlp0
diff

Git Link Reference:
https://github.com/jwood803/MLNetExamples/blob/master/MLNetExamples/NullValues/Program.cs

To print the data from the content:
https://stackoverflow.com/questions/62157982/how-to-view-data-inside-idataview

Reference for ML.net
https://learn.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/prepare-data-ml-net

first stored the data from the 
OneHotEncoding::
https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.categoricalcatalog.onehotencoding?view=ml-dotnet

TrainTest Split ::
https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.dataoperationscatalog.traintestsplit?view=ml-dotnet

Create New Column And append to csv::
https://social.msdn.microsoft.com/Forums/en-US/1d36373e-3631-4c5b-96c4-cc80605ea149/add-new-column-in-existing-csv-file-using-c?forum=aspgettingstarted

Machine Learning::
machine learning allows the user to feed a computer algorithm an immense amount of data and have the computer analyze and make data-driven recommendations and decisions based on only the input data.

SUPERVISED LEARNING:
Supervised learning, also known as supervised machine learning, is a subcategory of machine learning and artificial intelligence.
It is defined by its use of labeled datasets to train algorithms that to classify data or predict outcomes accurately. 
As input data is fed into the model, it adjusts its weights until the model has been fitted appropriately, 
which occurs as part of the cross validation process. Supervised learning helps organizations solve for a variety of real-world 
problems at scale, such as classifying spam in a separate folder from your inbox.

Examples:: Image- and object-recognition,Predictive analytics,Customer sentiment analysis,Spam detection.

ALgorithms:: Neural networks,Naive bayes,Linear regression,Logistic regression,Support vector machines (SVM),K-nearest neighbor,Random forest.

Supervised learning can be separated into two types of problems when data mining—
1)classification and 
2)Regression:

1)Classification uses an algorithm to accurately assign test data into specific categories.
It recognizes specific entities within the dataset and attempts to draw some conclusions 
on how those entities should be labeled or defined.
Classification algorithms are used when the output variable is categorical, which means there are 
two classes such as Yes-No, Male-Female, True-false, etc.
Common classification algorithms are linear classifiers, support vector machines (SVM),
decision trees, k-nearest neighbor, and random forest.

2)Regression is used to understand the relationship between dependent and independent variables. 
It is commonly used to make projections, such as for sales revenue for a given business. 
Linear regression, logistical regression, and polynomial regression are popular regression algorithms.

3)Decisssion Tree
4)Random Forest
------------------------------------------------------------------------------------------------------------------------

UNSUPERVISED LEARNING::

As the name suggests, unsupervised learning is a machine learning technique in which models are not supervised using 
training dataset. Instead, models itself find the hidden patterns and insights from the given data. 
It can be compared to learning which takes place in the human brain while learning new things. 

It can be defined as:
Unsupervised learning is a type of machine learning in which models are trained using unlabeled dataset and are allowed
to act on that data without any supervision.

Unsupervised learning cannot be directly applied to a regression or classification problem because unlike supervised 
learning, we have the input data but no corresponding output data. The goal of unsupervised learning is to find the 
underlying structure of dataset, group that data according to similarities, and represent that dataset in a compressed format.

List of some popular unsupervised learning algorithms:

K-means clustering
KNN (k-nearest neighbors)
Hierarchal clustering
Anomaly detection
Neural Networks
Principle Component Analysis
Independent Component Analysis
Apriori algorithm
Singular value decomposition

Classification Of Unsupervised Learning:Clustering and Association

Clustering: (svd,pca,k-means)
Clustering is a method of grouping the objects into clusters such that objects with most similarities remains into a group
and has less or no similarities with the objects of another group. Cluster analysis finds the commonalities between 
the data objects and categorizes them as per the presence and absence of those commonalities.
Association:(apriori,fp-growth)
An association rule is an unsupervised learning method which is used for finding the relationships between variables in the 
large database. It determines the set of items that occurs together in the dataset. Association rule makes marketing strategy 
more effective. Such as people who buy X item (suppose a bread) are also tend to purchase Y (Butter/Jam) item. 
A typical example of Association rule is Market Basket Analysis.
Hidden market model:
-------------------------------------------------------------

REINFORCEMENT LEARNING ::
Reinforcement Learning is defined as a Machine Learning method that is concerned with how software agents should take actions in an environment. 
Reinforcement Learning is a part of the deep learning method that helps you to maximize some portion of the cumulative reward.

Example: chess game.

Algorithms:
Monte Carlo
Markov Decision Processes
Q-Learning
State-Action-Reward-State-Action (SARSA)
Deep Q Network (DQN)
Deep Deterministic Policy Gradient (DDPG)
Brute force
Value function
SAC (Soft Actor-Critic)
TD3 (Twin Delayed Deep Deterministic Policy Gradient)
PPO (Proximal Policy Optimization)
TRPO (Trust Region Policy Optimization)
NAF (Q-Learning with Normalized Advantage Functions)
A3C (Asynchronous Advantage Actor-Critic Algorithm)
Q-learning - Lambda (State–action–reward–state with eligibility traces) 
Model based value estimation.

Types of Reinforcement Learning
Two types of reinforcement learning methods are:
1)positive
2)Negative

Positive:
It is defined as an event, that occurs because of specific behavior. It increases the strength and the frequency 
of the behavior and impacts positively on the action taken by the agent.
This type of Reinforcement helps you to maximize performance and sustain change for a more extended period. However,
too much Reinforcement may lead to over-optimization of state, which can affect the results.

Negative:
Negative Reinforcement is defined as strengthening of behavior that occurs because of a negative condition which should have stopped or avoided.
It helps you to define the minimum stand of performance. 
However, the drawback of this method is that it provides enough to meet up the minimum behavior.
-------------------------------------------------------
Is prediction supervised or unsupervised?
Image result for does supervised ml predict rating
Supervised learning models help predict outcomes for future data sets, whereas unsupervised learning allows 
you to discover hidden patterns within a dataset without the need for human input.
-------------------------------------------------------

Classify the problems as supervised, unsupervised, reinforcement or semi supervised
a. Spam filtering: Is an email spam or not - (Supervised - classification)
b. Given a list of customers and information about them, discover groups of similar
users. This knowledge can then be used for targeted marketing (unsupervised - clustering)
c. Robotics: A robot is in a maze, and it needs to find a way out.(Reinforcement-
d. Training an AI for a complex game such as Civilization or Dota.(Reinforcement-
e. Anomaly detection: Given measurements from sensors in a manufacturing
facility, identify anomalies, i.e. that something is wrong(supervised - anamoly detection - problem)
f. Discover patterns in data such as whenever it rains, people tend to stay indoors.
When it is hot, people buy more ice-cream.(supervised - classification)
g. Given information about a house, predict its price(supervised - Regression)
h. Netflix: Given a user and a movie, predict the rating the user is going to give to
the movie(supervised - regression)
i. Given an image, output which objects are present in the image(supervised-)

-----------------------------------------------------------------------

predict price - regression - float type - real number - supervised

classification - if already a class is defined

Image has float numbers

https://stackoverflow.com/questions/15907934/how-to-make-data-reading-and-preprocessing-faster-in-c-sharp
https://devindeep.com/how-to-preprocess-data-using-ml-net/

use mean imputation.

One hot encoding
One hot encoding takes a finite set of values and maps them onto integers whose binary representation has a 
single 1 value in unique positions in the string. One hot encoding can be the best choice if there is no implicit ordering of the categorical data.

//Row view
            /*foreach (var row in preview.RowView)
            {
                Console.WriteLine();
                foreach (var col in row.Values)
                {
                    if (col.Key == "Features")
                    {
                        continue;
                    }
                    count1++;
                    Console.Write($"{col.Value}\t");
                }
                Console.WriteLine(count1 + "\t");
            }
            Console.WriteLine("\nCount: {0}\n", preview.RowView.Length);
            */
//Column view
            foreach (var row in preview.ColumnView)
            {
                Console.WriteLine();
                foreach (var col in row.Values)
                {
                    count1++;
                    Console.Write($"{col}\t");
                }
                Console.WriteLine(count1 + "\t");
                
            }

// calculating the sum of the column values

string ColumnName = row.Column.Name.ToString();
                if(ColumnName == "Age")
                {
                    foreach (var col in row.Values)
                    {
                        count1++;
                        //Console.Write($"{col}\t");
                        int ageValue = Convert.ToInt32(col);

                        sumOfAge += ageValue;
                    }
                }
Console.WriteLine(sumOfAge);
            meanOfAge = (sumOfAge/ preview.RowView.Length);
            Console.WriteLine(meanOfAge);
            Console.WriteLine("\nCount: {0}\n", preview.RowView.Length);
-----------------------------------------------------------------------------------
Feature Scaling ::
Feature Scaling is a technique to standardize the independent features present in the data in a fixed range. 
It is performed during the data pre-processing. Working: Given a data-set with features- Age, Salary, BHK Apartment 
with the data size of 5000 people, each having these independent data features.

(maxValue-minValue)/

(x-min)/(max-min) 

https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.dataoperationscatalog.traintestsplit?view=ml-dotnet

Difference btwn:
https://www.geeksforgeeks.org/normalization-vs-standardization/

Standardization or Z-Score Normalization is the transformation of features by subtracting from mean and dividing by standard deviation. 
Normalization transforms the original values to fit within a certain range, standardization transforms them to fit within a distribution that has a mean of 0 and standard deviation of 1. This operation is also called getting Z-scores

on test - featurization
do all on train data. do till feature scaling.
then building of model on train set.
build linear regression model, 
find

remove null values
feature scaling
build model on training data. refere to ML.net linear regression
just standardize test data

Find accuracy:
-------------------
by calculating root Mean Square Value by formula:

RMSE = Math.sqrt((Math.Pow((ytest-yPredict),2))/N)

difference = Y_test - y_pred

mean_absolute_error = np.mean(abs(difference))

print(f"Mean Absolute Error  :  {mean_absolute_error}")

mean_squared_error = np.mean(difference**2)

print(f"Mean Squared Error  :  {mean_squared_error}")

root_mean_squared_error = np.sqrt(mean_squared_error)

print(f"Root Mean Squared Error  :  {root_mean_squared_error}")

r2 = 1-(sum(difference**2)/sum((Y_test-np.mean(Y_test))**2))

print(f"R - Squared  :  {r2}")

adjusted_r_squared = 1 - (((1-r2)*(len(Y_test)-1))/

test.csv data ko normalize

x, y seperate
x_test, y_test seperate krlo

155 line pe x ki jagah x_test

pass krna hai
u will get y_pred

y_pred will the predicted result
then do mean absolute error
